export const environment = {
  production: false,
  application: {
    name: '主泵故障诊断系统',
    logoUrl: 'assets/logo.png'
  },
  oAuthConfig: {
    issuer: 'https://localhost:44367',
    clientId: 'PrimaryPumpFds_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'PrimaryPumpFds',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44367'
    }
  },
  localization: {
    defaultResourceName: 'PrimaryPumpFds'
  }
};
