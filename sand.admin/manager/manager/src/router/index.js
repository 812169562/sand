import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/Index'
import User from '@/components/users/User'
import Tenant from '@/components/users/tenant'

Vue.use(Router)

export default new Router({
  routes: [
    { path: '/index',
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
})
