import Vue from 'vue'
import axios from 'axios'
import qs from 'qs'
import Vuex from 'vuex'
import {Message} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(Vuex)
Vue.use(qs)
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
Request.put = function (url, data, success, error) {
  axios({
    method: 'put',
    url: url,
    data: qs.stringify(data),
    headers: {
      'Content-type': 'application/x-www-form-urlencoded'
    }
  })
  .then(success)
  .catch(function (respose) {
    this.$message({
      showClose: true,
      message: '警告哦，这是一条警告消息',
      type: 'warning'
    })
  })
}
export default Request
