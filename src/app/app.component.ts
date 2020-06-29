import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { AddReplaceableComponent } from '@abp/ng.core';
import { eThemeBasicComponents } from '@abp/ng.theme.basic';
import { LogoComponent, RoutesComponent } from './theme/components';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <router-outlet></router-outlet>
  `
})
export class AppComponent implements OnInit {
  constructor(private store: Store) {}

  ngOnInit() {
    this.store.dispatch(
      new AddReplaceableComponent({
        component: LogoComponent,
        key: eThemeBasicComponents.Logo,
      }),
    );
    this.store.dispatch(
      new AddReplaceableComponent({
        component: RoutesComponent ,
        key: eThemeBasicComponents.Routes,
      }),
    );
  }
}
