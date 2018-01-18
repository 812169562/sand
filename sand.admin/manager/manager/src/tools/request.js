import Vue from 'vue'
import axios from 'axios'
import qs from 'qs'
import Vuex from 'vuex'
import {Message} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(Vuex)
Vue.use(Message)
let Request = {}
Request.get = function (url, data, success, error) {
  axios({
    method: 'get',
    url: url,
    data: qs.stringify(data),
    headers: {
      'Content-type': 'application/x-www-form-urlencoded'
    }
  })
  .then(success)
  .catch(function (respose) {
    alert(respose)
  })
}
Request.put = function (url, data, callback, error) {
  axios({
    method: 'put',
    url: url,
    data: qs.stringify(data),
    headers: {
      'Content-type': 'application/x-www-form-urlencoded'
    }
  })
  .then(function (respose) {
    console.log(respose)
    console.log(respose.data)
    if (respose.data.code === 2) {
      debugger
      Message({
        showClose: true,
        message: respose.data.message,
        type: 'warning'
      })
    }
    callback(respose.data.data)
  })
  .catch(function (respose) {
  })
}
export default Request
