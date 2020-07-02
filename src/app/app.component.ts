import { Component, OnInit } from '@angular/core';
import { Store } from '@ngxs/store';
import { AddReplaceableComponent, ConfigStateService } from '@abp/ng.core';
import { eThemeBasicComponents } from '@abp/ng.theme.basic';
import { LoginComponent, LogoComponent, ProfileComponent, RoutesComponent } from './theme/components';
import { eIdentityRouteNames } from '@abp/ng.identity';
import { MainLayoutComponent } from './theme/layouts';
import { eAccountComponents } from '@abp/ng.account';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <router-outlet></router-outlet>
  `
})
export class AppComponent implements OnInit {
  constructor(private store: Store, private config: ConfigStateService) {}

  ngOnInit() {
    this.replaceComponents();
    this.patchRoutes();
  }

  private replaceComponents() {
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
    this.store.dispatch(
      new AddReplaceableComponent({
        component: ProfileComponent ,
        key: eThemeBasicComponents.NavItems,
      }),
    );
    this.store.dispatch(
      new AddReplaceableComponent({
        component: MainLayoutComponent ,
        key: eThemeBasicComponents.ApplicationLayout,
      }),
    );
    this.store.dispatch(
      new AddReplaceableComponent({
        component: LoginComponent ,
        key: eAccountComponents.Login,
      }),
    );
  }

  private patchRoutes() {
    this.config.dispatchPatchRouteByName(eIdentityRouteNames.Administration, { iconClass: 'cluster'})
    this.config.dispatchPatchRouteByName(eIdentityRouteNames.Users, { iconClass: 'user'})
    this.config.dispatchPatchRouteByName(eIdentityRouteNames.Roles, { iconClass: 'idcard'})
  }
}
