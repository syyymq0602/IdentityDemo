import {
  ApplicationConfiguration,
  AuthService,
  ConfigState
} from '@abp/ng.core';
import { Component } from '@angular/core';
import { Navigate, RouterState } from '@ngxs/router-plugin';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: 'profile.component.html',
})
export class ProfileComponent {
  @Select(ConfigState.getOne('currentUser'))
  currentUser$: Observable<ApplicationConfiguration.CurrentUser>;

  @Select(ConfigState.getDeep('localization.languages'))
  languages$: Observable<ApplicationConfiguration.Language[]>;

  constructor(private store: Store, private authService: AuthService) {}

  logout() {
    this.authService.logout().subscribe(() => {
      this.store.dispatch(
        new Navigate(['/'], null, {
          state: { redirectUrl: this.store.selectSnapshot(RouterState).state.url },
        }),
      );
    });
  }
}
