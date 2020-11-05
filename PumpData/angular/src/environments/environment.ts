import { Config } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'PumpData',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44345',
    redirectUri: baseUrl,
    clientId: 'PumpData_App',
    responseType: 'code',
    scope: 'offline_access PumpData',
  },
  apis: {
    default: {
      url: 'https://localhost:44345',
      rootNamespace: 'PumpData',
    },
  },
} as Config.Environment;
