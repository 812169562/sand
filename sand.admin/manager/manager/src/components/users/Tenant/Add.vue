<template>
 <el-dialog
  title="新增信息"
  :visible.sync="dialogVisible"
  width="45%"
  height="75%"
  :close-on-click-modal="false" :before-close="hidden">
    <el-form :model="form">
       <mu-text-field label="名称" hintText="请输入名称" v-model="form.tenantName"  lab labelFloat/>
       <mu-text-field label="电话号码" hintText="请输入电话号码" v-model="form.telPhone"  lab labelFloat/>
       <mu-text-field label="联系人" hintText="请输入联系人" v-model="form.telName"  lab labelFloat/><br/>
       <mu-text-field label="营业执照" hintText="请输入营业执照" v-model="form.businessCertificate"  lab labelFloat/>
        <mu-date-picker container="inline" mode="landscape" v-model="form.endTime" hintText="内联横屏模式选择" format="yyyy-MM-dd"/>
       <mu-text-field label="类型" hintText="请输入类型" v-model="form.Type"  lab labelFloat/><br/>
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
  name: "tenant-add",
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
  data() {
    return {
      form: {}
    };
  },
  mounted: () => {
    if (this.id) {
      this.init();
    }
  },
  methods: {
    init() {
      this.form = {
        telName: "",
        telPhone: "",
        tenantName: "",
        businessCertificate: "",
        endTime: "",
        type: ""
      };
    },
    hidden(refresh) {
      this.$emit("closeAdd", false, refresh);
    },
    save() {
      let _this = this;
      this.$request.add("tenant", { tenant: this.form }, function(respose) {
        if (respose.code === 1) {
          _this.init();
          _this.hidden(true);
        }
      });
    }
  }
};
</script>
