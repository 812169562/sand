import Vue from 'vue'
import axios from 'axios'
import qs from 'qs'
import Vuex from 'vuex'
import {Message, Loading} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(Vuex)
Vue.use(Message)
Vue.use(Loading)
let Request = {}
Request.get = function (url, data, callback, error) {
  let loadingInstance = Loading.service({fullscreen: true, background: '#F8F8FF'})
  console.log(data)
  axios({
    method: 'get',
    url: url,
    params: data,
    headers: {
      'Content-type': 'application/json'
    }
  })
  .then(function (respose) {
    if (respose.data.code === 2) {
      Message({
        showClose: true,
        message: respose.data.message,
        type: 'warning'
      })
      return
    }
    loadingInstance.close()
    callback(respose.data)
  })
  .then(function () {
    loadingInstance.close()
  })
  .catch(function (respose) {
    loadingInstance.close()
  })
}
Request.put = function (url, data, callback, error) {
  let loadingInstance = Loading.service({ fullscreen: true })
  console.log(data)
  axios({
    method: 'put',
    url: url,
    data: qs.stringify(data),
    headers: {
      'Content-type': 'application/x-www-form-urlencoded'
    }
  })
  .then(function (respose) {
    if (respose.data.code === 2) {
      Message({
        showClose: true,
        message: respose.data.message,
        type: 'warning'
      })
      return
    }
    loadingInstance.close()
    callback(respose.data)
  })
  .then(function () {
    loadingInstance.close()
  })
  .catch(function (respose) {
    loadingInstance.close()
  })
}
export default Request
