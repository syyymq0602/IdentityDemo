import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  constructor(private oAuthService: OAuthService) {
  }

  get hasLoggedIn(): boolean {
    return this.oAuthService.hasValidAccessToken();
  }
}