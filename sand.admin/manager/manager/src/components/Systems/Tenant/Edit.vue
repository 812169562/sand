<template>
 <el-dialog
  title="新增信息"
  :visible.sync="dialogVisible"
  width="55%"
  height="75%"
  :close-on-click-modal="false" :before-close="hidden" @open="open">
    <el-form :model="form">
         <mu-text-field label="租户" hintText="请输入租户" v-model="form.tenantId"  lab labelFloat/>
         <mu-text-field label="租户名" hintText="请输入租户名" v-model="form.tenantName"  lab labelFloat/>
         <mu-text-field label="联系人" hintText="请输入联系人" v-model="form.telName"  lab labelFloat/>
         <mu-text-field label="联系地址" hintText="请输入联系地址" v-model="form.address"  lab labelFloat/>
         <mu-text-field label="联系电话" hintText="请输入联系电话" v-model="form.telPhone"  lab labelFloat/>
         <mu-text-field label="营业证书" hintText="请输入营业证书" v-model="form.businessCertificate"  lab labelFloat/>
         <mu-text-field label="代码" hintText="请输入代码" v-model="form.code"  lab labelFloat/>
         <mu-date-picker  label="结束日期" hintText="请输入结束日期" v-model="form.endTime"  lab labelFloat/>
         <mu-text-field label="类型" hintText="请输入类型" v-model="form.type"  lab labelFloat/>
         <mu-text-field label="状态" hintText="请输入状态" v-model="form.status"  lab labelFloat/>
  </el-form>
  <span slot="footer" class="dialog-footer">
     <mu-raised-button label="取 消" class="demo-raised-button" @click="hidden()" secondary/>
     <span>  </span>
     <mu-raised-button label="确 定" class="demo-raised-button" @click="save()"/>
  </span>
</el-dialog>
</template>
<script>
export default {
  /** 组件名称 */
  name: "tenant-edit",
    /** 属性
   * @property 是否可见
   * @property 选中数据编号
   */
  props: {
    dialogVisible: {
      type: Boolean,
      default: false
    },
    id: {
      type: String,
      default: ""
    }
  },
  /** 绑定数据 */
  data() {
    return {
      /** 表单数据 */
      form: {},
      /** 表单标题 */
      title: '新增租户信息'
    };
  },
  methods: {
    /** 初始化 */
    init() {
      this.form = {
         /** 租户名 */
        tenantName: '',
         /** 联系人 */
        telName: '',
         /** 联系地址 */
        address: '',
         /** 联系电话 */
        telPhone: '',
         /** 营业证书 */
        businessCertificate: '',
         /** 代码 */
        code: '',
         /** 结束日期 */
        endTime: '',
        /** 类型 */
        type: ''
      };
    },
    /** 隐藏页面 */
    hidden(refresh) {
      this.$emit('closeAdd', false, refresh);
    },
    /** 保存页面信息 */
    save() {
      let _this = this;
      this.$request.save('tenant', { tenant: this.form }, function(respose) {
        if (respose.code === 1) {
          _this.init();
          _this.hidden(true);
        }
      }, this.id);
    },
   /** 打开页面信息 */
    open() {
      if (!this.id) {
        this.init();
      } else {
        this.title = '编辑租户信息';
        let _this = this;
        this.$request.get('tenant/' + this.id, {}, (respose) => {
          _this.form = respose.data;
        });
      }
    }
  }
};
</script>
