import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'BooksApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44360',
    redirectUri: baseUrl,
    clientId: 'BooksAppStore_App',
    responseType: 'code',
    scope: 'offline_access openid profile role email phone BooksAppStore',
  },
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'BooksAppStore',
    },
  },
} as Environment;
