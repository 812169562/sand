import Vue from 'vue';
import axios from 'axios';
import qs from 'qs';
import Vuex from 'vuex';
import { Message, Loading, MessageBox } from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';

Vue.use(Vuex);
Vue.use(Loading);

/**
 * http请求
 * @property get-查询
 * @property post-更新
 * @property add-新增
 * @property delete-删除
 * @property stop-停用
 */
let Request = {
  /**
   * 查询操作-发起get请求,主要用于查询数据用
   * @param {url}         需要发送请求的地址
   * @param {data}        请求无格式数据
   * @param {callback}    回调函数
   */
  get: (url, data, callback) => {
    let loadingInstance = Loading.service({
      fullscreen: true,
      background: '#F8F8FF'
    });
    axios({
      method: 'get',
      url: url,
      params: data,
      headers: {
        'Content-type': 'application/json'
      }
    })
      .then(function(respose) {
        if (respose.data.code === 2) {
          Message({
            showClose: true,
            message: respose.data.message,
            type: 'warning'
          });
          return;
        }
        callback(respose.data);
      })
      .then(function() {
        loadingInstance.close();
      })
      .catch(function(respose) {
        loadingInstance.close();
      });
  },
  /**
   * 更新操作-发起post请求,主要用于更新数据用
   * @param {string}      需要发送请求的地址
   * @param {Json}        请求无格式数据
   * @param {Function}    回调函数
   * @param {Function}    回调函数异常时传入
   */
  post: (url, data, callback, error) => {
    let loadingInstance = Loading.service({ fullscreen: true });
    axios({
      method: 'post',
      url: url,
      data: data,
      headers: {
        'Content-type': 'application/json-patch+json'
      }
    })
      .then(function(respose) {
        if (respose.data.code === 2) {
          Message({
            showClose: true,
            message: respose.data.message,
            type: 'warning'
          });
          return;
        }
        callback(respose.data);
      })
      .then(function() {
        loadingInstance.close();
      })
      .catch(function(respose) {
        MessageBox.alert('请求错误请联系管理员！');
        loadingInstance.close();
      });
  },
  /**
   * 新增操作-发起put请求,主要用于新增数据数据用
   * @param {string}      需要发送请求的地址
   * @param {Json}        请求无格式数据
   * @param {Function}    回调函数
   * @param {Function}    回调函数异常时传入
   */
  add: (url, data, callback, error) => {
    let loadingInstance = Loading.service({ fullscreen: true });
    axios({
      method: 'put',
      url: url,
      data: data,
      headers: {
        'Content-type': 'application/json-patch+json'
      }
    })
      .then(function(respose) {
        if (respose.data.code === 2) {
          Message({
            showClose: true,
            message: respose.data.message,
            type: 'warning'
          });
          return;
        }
        callback(respose.data);
      })
      .then(function() {
        loadingInstance.close();
      })
      .catch(function(respose) {
        loadingInstance.close();
        MessageBox.alert('请求错误请联系管理员！');
      });
  },
  /**
   * 删除操作-发起delete请求,主要用于删除数据用
   * @param {string}      需要发送请求的地址
   * @param {Json}        请求无格式数据
   * @param {Function}    回调函数
   * @param {Function}    回调函数异常时传入
   * @param {message}     传入的消息
   */
  delete: (url, data, callback, message = '此操作将永久删除该数据') => {
    MessageBox.confirm(message + ', 是否继续?', '提示', {
      confirmButtonText: '确定',
      cancelButtonText: '取消',
      type: 'warning',
      center: true
    })
      .then(() => {
        let loadingInstance = Loading.service({ fullscreen: true });
        axios({
          method: 'delete',
          url: url,
          data: qs.stringify(data),
          headers: {
            'Content-type': 'application/x-www-form-urlencoded'
          }
        })
          .then(respose => {
            if (respose.data.code === 2) {
              Message({
                showClose: true,
                message: respose.data.message,
                type: 'warning'
              });
              return;
            }
            MessageBox.alert('处理成功');
            callback(respose.data);
          })
          .then(() => {
            loadingInstance.close();
          })
          .catch(() => {
            loadingInstance.close();
            MessageBox.alert('请求错误请联系管理员！');
          });
      })
      .catch(() => {});
  },
  /**
   * 停用操作-发起post请求,主要用于停用数据用
   * @param {string}      需要发送请求的地址
   * @param {Json}        请求无格式数据
   * @param {Function}    回调函数
   * @param {Function}    回调函数异常时传入
   * @param {message}     传入的消息
   */
  stop: (url, data, callback, error, message = '') => {
    message = !message ? '是否停用该项目' : message;
    MessageBox.confirm(message + ', 是否继续?', '提示', {
      confirmButtonText: '确定',
      cancelButtonText: '取消',
      type: 'warning',
      center: true
    })
      .then(() => {
        let loadingInstance = Loading.service({ fullscreen: true });
        axios({
          method: 'post',
          url: url,
          data: qs.stringify(data),
          headers: {
            'Content-type': 'application/x-www-form-urlencoded'
          }
        })
          .then(function(respose) {
            if (respose.data.code === 2) {
              Message({
                showClose: true,
                message: respose.data.message,
                type: 'warning'
              });
              return;
            }
            callback(respose.data);
          })
          .then(function() {
            loadingInstance.close();
          })
          .catch(function(respose) {
            loadingInstance.close();
            MessageBox.alert('请求错误！');
          });
      })
      .catch(() => {});
  },
  /**
   * 更新操作-发起post或者put请求请求,主要用于保存数据用
   * @param {string}      需要发送请求的地址
   * @param {Json}        请求无格式数据
   * @param {Json}        是否更新
   * @param {Function}    回调函数
   * @param {Function}    回调函数异常时传入
   */
  save: (url, data, callback, isupdate = false, error) => {
    if (isupdate) {
      Request.post(url, data, callback, error);
    } else {
      Request.add(url, data, callback, error);
    }
  }
};
export default Request;
