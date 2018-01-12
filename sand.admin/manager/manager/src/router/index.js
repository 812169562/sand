import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/index'
import User from '@/components/users/user'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'user',
      component: User
    },
    { path: '/',
      name: 'index',
      component: Index
    }
  ]
})
