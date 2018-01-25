// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import MuseUI from 'muse-ui'
import 'muse-ui/dist/muse-ui.css'
import 'muse-ui/dist/theme-light.css'
import {Container, Header, Aside, Main, Footer, Dialog, Form, FormItem, Row, Col, Loading, Button, DatePicker, TimePicker, TimeSelect, Pagination, Table, TableColumn, Select, Message} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import axios from 'axios'
import qs from 'qs'
import Vuex from 'vuex'
import Request from './tools/request'

Vue.config.productionTip = false
Vue.use(MuseUI)
Vue.use(Container)
Vue.use(DatePicker)
Vue.use(TimePicker)
Vue.use(TimeSelect)
Vue.use(Select)
Vue.use(Header)
Vue.use(Aside)
Vue.use(Main)
Vue.use(Footer)
Vue.use(Dialog)
Vue.use(Form)
Vue.use(FormItem)
Vue.use(Loading)
Vue.use(Row)
Vue.use(Col)
Vue.use(Vuex)
Vue.use(qs)
Vue.use(Request)
Vue.use(Pagination)
Vue.use(Table)
Vue.use(TableColumn)
Vue.use(Button)

axios.defaults.withCredentials = true
Vue.prototype.$http = axios
Vue.prototype.$qs = qs
Vue.prototype.$request = Request
Vue.prototype.$message = Message
axios.defaults.baseURL = 'http://localhost:5001/api/'

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
