import { ABP } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// 导航栏路由管理
const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
    data: {
      routes: {
        name: '::Menu:Home',
        iconClass: 'home'
      } as ABP.Route
    }
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule)
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule)
  },
  {
    path: 'setting-management',
    loadChildren: () => import('@abp/ng.setting-management').then(m => m.SettingManagementModule)
  },
  {
    //自定义导航栏路由
    path: 'test',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule),
    data: {
      routes: {
        name: '文件',
        order: 101,
        iconClass: 'fas fa-question-circle',
        children: [
          {
            path: 'child',
            name: '添加',
            order: 1,
          },
          {
            path: 'child',
            name: '修改',
            order: 2,
          },
          {
            path: 'child',
            name: '搜索',
            order: 3,
          },

        ],
      } as ABP.Route,
    }
  },
  {
    path: 'test',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule),
    data: {
      routes: {
        name: '编辑',
        order: 101,
        iconClass: 'fas fa-question-circle',
        children: [
          {
            path: 'child',
            name: '添加',
            order: 1,
          },
          {
            path: 'child',
            name: '删除',
            order: 2,
          },

        ],
      } as ABP.Route,
    }
  },
  {
    path: 'test',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule),
    data: {
      routes: {
        name: '帮助',
        order: 101,
        iconClass: 'fas fa-question-circle',
        children: [
          {
            path: 'child',
            name: '帮助文档',
            order: 1,
          },

        ],
      } as ABP.Route,
    }
  },
  {
    path: 'test',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule),
    data: {
      routes: {
        name: '其它',
        order: 101,
        iconClass: 'fas fa-question-circle',
        children: [
          {
            path: 'child',
            name: '操作指南',
            order: 1,
          },

        ],
      } as ABP.Route,
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
