using System.Text.Json;
using IdentityModel.Client;

const string authorizationServer = "https://localhost:5301";
const string identityServer = "https://localhost:6301/identity";

var client = new HttpClient();

// 源码里将authorizationServer转换为 https://localhost:5301/.well-known/openid-configuration
var disco = await client.GetDiscoveryDocumentAsync(authorizationServer);
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}

await ClientCredentialsAsync(client, disco);

await PasswordCheckAsync(client,disco);
            

// 此为使用 ClientCredentials 认证
async Task ClientCredentialsAsync(HttpMessageInvoker messageInvoker, DiscoveryDocumentResponse discovery)
{
    // request token
    var tokenResponse = await messageInvoker.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
    {
        // ClientCredentials 模式需要 client_id client_secret scope 以及 TokenEndpoint
        Address = discovery.TokenEndpoint,
        ClientId = "client",
        ClientSecret = "secret",
        Scope = "api1"
    });
    if (tokenResponse.IsError)
    {
        Console.WriteLine(tokenResponse.Error);
        return;
    }

    Console.WriteLine(tokenResponse.Json);
    Console.WriteLine("\n");

    await GetUserClaimsFromApiAsync(tokenResponse);
}

// 此为使用Password验证
async Task PasswordCheckAsync(HttpMessageInvoker clientInvoker, DiscoveryDocumentResponse discovery)
{
    var res = await clientInvoker.RequestPasswordTokenAsync(new PasswordTokenRequest
    {
        // 需要的client_id secret username password scope
        Address = discovery.TokenEndpoint,
        ClientId = "custom",
        ClientSecret = "secret",
        // 与 IdentityServer.CustomUsers 中匹配
        UserName = "bob",
        Password = "bob",
        // 属于 IdentityServer.Config 中的 AllowedScopes
        // 如果未指定 Scope ，则将为所有明确允许的范围发出令牌。
        Scope = "openid scope2"
    });
    if (res.IsError)
    {
        Console.WriteLine(res.Error);
    }
    
    Console.WriteLine(res.Json);

    // 从 https://localhost:5201/connect/userinfo 获取用户信息，信息量多少与 发送的Scope有关
    var info = await clientInvoker.GetUserInfoAsync(new UserInfoRequest
    {
        Address = discovery.UserInfoEndpoint,
        Token = res.AccessToken
    });
    if (info.IsError)
    {
        Console.WriteLine(info.Error);
        return;
    }
    
    var docs = info.Json;
    Console.WriteLine(JsonSerializer.Serialize(docs, new JsonSerializerOptions { WriteIndented = true }));

    await GetUserClaimsFromApiAsync(res);
}

async Task GetUserClaimsFromApiAsync(TokenResponse tokenResponse)
{
    var apiClient = new HttpClient();
    // api服务器需要设置访问令牌
    apiClient.SetBearerToken(tokenResponse.AccessToken);

    var response = await apiClient.GetAsync(identityServer);
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine(response.StatusCode);
    }
    else
    {
        var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
        Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
    }
}