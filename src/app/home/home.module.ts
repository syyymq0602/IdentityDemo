import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';

import {
  NzButtonModule,
  NzCardModule, NzDescriptionsModule,
  NzDividerModule, NzGridModule,
  NzIconModule,
  NzLayoutModule,
  NzMenuModule, NzTableModule,
  NzTypographyModule
} from 'ng-zorro-antd';

import { NzSpaceModule } from 'ng-zorro-antd/space';
import { WelcomeComponent } from './welcome/welcome.component';
import { ThemeModule } from '../theme/theme.module';
import { RealTimeParamComponent } from './real-time-param/real-time-param.component';
import { ParamMonitorComponent } from './param-monitor/param-monitor.component';
import { DiagnosticResultsComponent } from './diagnostic-results/diagnostic-results.component';
import { DecissionSupportComponent } from './decission-support/decission-support.component';

@NgModule({
  declarations:
    [
      HomeComponent,
      WelcomeComponent,
      RealTimeParamComponent,
      ParamMonitorComponent,
      DecissionSupportComponent,
      DiagnosticResultsComponent
    ],
  imports: [
    SharedModule,
    HomeRoutingModule,
    NzCardModule,
    NzTypographyModule,
    NzButtonModule,
    NzSpaceModule,
    ThemeModule,
    NzLayoutModule,
    NzMenuModule,
    NzIconModule,
    NzDividerModule,
    NzGridModule,
    NzDescriptionsModule,
    NzTableModule
  ]
})
export class HomeModule {
}
