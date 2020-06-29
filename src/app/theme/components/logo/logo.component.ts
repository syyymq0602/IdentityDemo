import { Component } from '@angular/core';
import { Config, ConfigState } from '@abp/ng.core';
import { Store } from '@ngxs/store';

@Component({
  selector: 'app-logo',
  template: `
    <a class="navbar-brand" href="/">
      <img
        [src]="appInfo.logoUrl"
        [alt]="appInfo.name"
      /> {{ appInfo.name }}
    </a>
  `
})
export class LogoComponent {
  get appInfo(): Config.Application {
    return this.store.selectSnapshot(ConfigState.getApplicationInfo);
  }

  constructor(private store: Store) {}
}
