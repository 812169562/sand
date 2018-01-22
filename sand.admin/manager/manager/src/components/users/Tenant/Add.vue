<template>
 <el-dialog
  title="新增信息"
  :visible.sync="dialogVisible"
  width="45%"
  height="75%"
  :close-on-click-modal="false">
    <el-form :model="form">
       <mu-text-field label="名称" hintText="请输入名称" v-model="form.TenantName"  lab labelFloat/>
       <mu-text-field label="电话号码" hintText="请输入电话号码" v-model="form.TelPhone"  lab labelFloat/>
       <mu-text-field label="联系人" hintText="请输入联系人" v-model="form.TelName"  lab labelFloat/><br/>
       <mu-text-field label="营业执照" hintText="请输入营业执照" v-model="form.BusinessCertificate"  lab labelFloat/>
       <mu-text-field label="关闭时间" hintText="请输入关闭时间" v-model="form.EndTime"  lab labelFloat/>
       <mu-text-field label="类型" hintText="请输入类型" v-model="form.Type"  lab labelFloat/><br/>
  </el-form>
  <span slot="footer" class="dialog-footer">
     <mu-raised-button label="取 消" class="demo-raised-button" @click="dialogVisible = false" secondary/>
     <span>  </span>
     <mu-raised-button label="确 定" class="demo-raised-button" @click="add()" primary/>
  </span>
</el-dialog>
</template>
<script>
export default {
  name: 'tenant-add',
  props: {
    dialogVisible: {
      type: Boolean,
      default: false
    }
  },
  data () {
    return {
      form: {
        TelName: "",
        TelPhone: "",
        TenantName: "",
        BusinessCertificate: "",
        EndTime: "",
        Type: ""
      },
      visible: true
    }
  },
  methods: {
  }
}
</script>
