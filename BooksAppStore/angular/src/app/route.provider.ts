import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
        invisible:false
      },
      {
        path:'/book-store',
        name: '::Menu:BookStore',
        iconClass: 'fa fa-cog fa-spin',
        order:2,
        layout:eLayoutType.application,
      },
      {
        path:'/books',
        name:'::Menu:Books',
        parentName:'::Menu:BookStore',
        layout:eLayoutType.application,
        requiredPolicy: 'BooksAppStore.Books',
      }
    ]);
  };
}
