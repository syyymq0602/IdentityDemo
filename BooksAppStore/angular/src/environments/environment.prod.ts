import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'BooksAppStore',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44360',
    redirectUri: baseUrl,
    clientId: 'BooksAppStore_App',
    responseType: 'code',
    scope: 'offline_access BooksAppStore',
  },
  apis: {
    default: {
      url: 'https://localhost:44360',
      rootNamespace: 'BooksAppStore',
    },
  },
} as Environment;
