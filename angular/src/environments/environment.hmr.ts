export const environment = {
  production: false,
  hmr: true,
  application: {
    name: 'CaveRegister',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44308',
    clientId: 'CaveRegister_App',
    dummyClientSecret: '1q2w3e*',
    scope: 'CaveRegister',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44308',
    },
  },
  localization: {
    defaultResourceName: 'CaveRegister',
  },
};
