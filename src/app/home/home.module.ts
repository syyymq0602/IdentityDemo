import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { NzButtonModule, NzCardModule, NzTypographyModule } from 'ng-zorro-antd';
import { NzSpaceModule } from 'ng-zorro-antd/space';
import { WelcomeComponent } from './welcome/welcome.component';
import { ThemeModule } from '../theme/theme.module';
import { RealTimeParamComponent } from './real-time-param/real-time-param.component';

@NgModule({
  declarations: [HomeComponent, WelcomeComponent, RealTimeParamComponent],
  imports: [
    SharedModule,
    HomeRoutingModule,
    NzCardModule,
    NzTypographyModule,
    NzButtonModule,
    NzSpaceModule,
    ThemeModule
  ]
})
export class HomeModule {
}
