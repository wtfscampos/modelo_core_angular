import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd, Event, PRIMARY_OUTLET } from '@angular/router';
import { filter, map, distinctUntilChanged } from 'rxjs/operators';
import { Breadcrumb } from './breadcrumb.model';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  styleUrls: ['./breadcrumb.component.css']
})
export class BreadcrumbComponent implements OnInit {

  itens: Breadcrumb[];

  // https://dev.to/zhiyueyi/create-a-simple-breadcrumb-in-angular-ag5
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.router.events.pipe(
      filter((event: Event) => event instanceof NavigationEnd),
      distinctUntilChanged(),
    ).subscribe(() => {
      this.itens = this.buildBreadCrumb(this.activatedRoute.root);
    })
  }

  buildBreadCrumb(route: ActivatedRoute, url: string = '', breadcrumbs: Breadcrumb[] = []): Breadcrumb[] {

      //If no routeConfig is avalailable we are on the root path
    let label = route.routeConfig && route.routeConfig.data ? route.routeConfig.data.breadcrumb : '';
    let path = route.routeConfig && route.routeConfig.data ? route.routeConfig.path : '';

     // If the route is dynamic route such as ':id'
    const lastRoutePart = path.split('/').pop();
    const isDynamicRoute = lastRoutePart.startsWith(':');
    if (isDynamicRoute && !!route.snapshot) {
      const paramName = lastRoutePart.split(':')[1];
      path = path.replace(lastRoutePart, route.snapshot.params[paramName]);
      label = label + " "+ route.snapshot.params[paramName];
    }

    //In the routeConfig the complete path is not available,
    //so we rebuild it each time
    const nextUrl = path ? `${url}/${path}` : url;

    const item: Breadcrumb = {
      label: label,
      url: nextUrl
    };
    // Only adding route with non-empty label
    const newBreadcrumbs = item.label ? [...breadcrumbs, item] : [...breadcrumbs];
    if (route.firstChild) {
      //If we are not on our current path yet,
      //there will be more children to look after, to build our breadcumb
      return this.buildBreadCrumb(route.firstChild, nextUrl, newBreadcrumbs);
    } 

    return newBreadcrumbs;
  }


}
