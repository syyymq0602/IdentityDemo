import { ABP, ConfigState } from '@abp/ng.core';
import { Component, Input, TrackByFunction } from '@angular/core';
import { Select } from '@ngxs/store';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-routes',
  templateUrl: 'routes.component.html',
  styleUrls: ['routes.component.scss'],
})
export class RoutesComponent {
  @Select(ConfigState.getOne('routes'))
  routes$: Observable<ABP.FullRoute[]>;

  @Input()
  smallScreen: boolean;

  get visibleRoutes$(): Observable<ABP.FullRoute[]> {
    return this.routes$.pipe(map(routes => getVisibleRoutes(routes)));
  }

  trackByFn: TrackByFunction<ABP.FullRoute> = (_, item) => item.name;
}

function getVisibleRoutes(routes: ABP.FullRoute[]) {
  return routes.reduce((acc, val) => {
    if (val.invisible) return acc;

    if (val.children && val.children.length) {
      val.children = getVisibleRoutes(val.children);
    }

    return [...acc, val];
  }, []);
}
