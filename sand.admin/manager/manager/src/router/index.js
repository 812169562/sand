import Vue from 'vue';
import Router from 'vue-router';
import Index from '@/components/Index';
import User from '@/components/systems/User';
import Tenant from '@/components/systems/tenant/list';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/index',
      name: 'Index',
      component: Index
    },
    {
      path: '/tenant',
      name: 'Tenant',
      component: Tenant
    },
    {
      path: '/user',
      name: 'User',
      component: User
    }
  ]
});
