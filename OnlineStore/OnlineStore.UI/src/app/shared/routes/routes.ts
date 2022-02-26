import { OnlineStoreRoute } from "./route.model";

// Home
export class HomeRoutes {
  public static root: OnlineStoreRoute = {
    path: '',
    url: '/'
  };
}

// Home
export class CatalogRoutes {
  public static root: OnlineStoreRoute = {
    path: 'catalog',
    url: '/catalog'
  };
  public static productView: OnlineStoreRoute = {
    path: 'produs',
    url: '/catalog/produs'
  };
  public static categories: OnlineStoreRoute = {
    path: 'categorii',
    url: '/catalog/categorii'
  };
}


// Admin
export class AdminRoutes {
  public static root: OnlineStoreRoute = {
    path: 'admin',
    url: '/admin'
  };
}
