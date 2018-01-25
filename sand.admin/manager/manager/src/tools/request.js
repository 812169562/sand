import Vue from 'vue'
import axios from 'axios'
import qs from 'qs'
import Vuex from 'vuex'
import {Message, Loading, MessageBox} from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(Vuex)
Vue.use(Loading)
let Request = {}
Request.get = (url, data, callback) => {
  let loadingInstance = Loading.service({fullscreen: true, background: '#F8F8FF'})
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
    callback(respose.data)
  })
  .then(function () {
    loadingInstance.close()
  })
  .catch(function (respose) {
    loadingInstance.close()
  })
}
Request.post = (url, data, callback, error) => {
  let loadingInstance = Loading.service({ fullscreen: true })
  axios({
    method: 'post',
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
    callback(respose.data)
  })
  .then(function () {
    loadingInstance.close()
  })
  .catch(function (respose) {
    loadingInstance.close()
  })
}
Request.add = (url, data, callback, error) => {
  let loadingInstance = Loading.service({ fullscreen: true })
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
    callback(respose.data)
  })
  .then(function () {
    loadingInstance.close()
  })
  .catch(function (respose) {
    loadingInstance.close()
  })
}
Request.delete = (url, data, callback, message = '') => {
  message = !message ? '此操作将永久删除该数据' : message
  MessageBox.confirm(message + ', 是否继续?', '提示', {
    confirmButtonText: '确定',
    cancelButtonText: '取消',
    type: 'warning',
    center: true
  }).then(() => {
    let loadingInstance = Loading.service({ fullscreen: true })
    axios({
      method: 'delete',
      url: url,
      data: qs.stringify(data),
      headers: {
        'Content-type': 'application/x-www-form-urlencoded'
      }
    }).then((respose) => {
      if (respose.data.code === 2) {
        Message({
          showClose: true,
          message: respose.data.message,
          type: 'warning'
        })
        return
      }
      MessageBox.alert("处理成功")
      callback(respose.data)
    }).then(() => {
      loadingInstance.close()
    }).catch(() => {
      loadingInstance.close()
    })
  })
}
Request.stop = (url, data, callback, error, message = '') => {
  message = !message ? '是否停用该项目' : message
  MessageBox.confirm(message + ', 是否继续?', '提示', {
    confirmButtonText: '确定',
    cancelButtonText: '取消',
    type: 'warning',
    center: true
  }).then(() => {
    let loadingInstance = Loading.service({ fullscreen: true })
    axios({
      method: 'post',
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
      callback(respose.data)
    })
    .then(function () {
      loadingInstance.close()
    })
    .catch(function (respose) {
      loadingInstance.close()
    })
  })
}
export default Request
