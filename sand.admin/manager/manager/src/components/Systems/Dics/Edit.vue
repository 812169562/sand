<template>
 <el-dialog
  title="新增信息"
  :visible.sync="dialogVisible"
  width="55%"
  height="75%"
  :close-on-click-modal="false" :before-close="close" @open="open" @close="close">
    <el-form :model="form">
         <mu-text-field label="代码" hintText="请输入代码" v-model="form.code"  lab labelFloat/>
         <mu-text-field label="名称" hintText="请输入名称" v-model="form.name"  lab labelFloat/>
         <mu-text-field label="拼音简拼" hintText="请输入拼音简拼" v-model="form.pinYin"  lab labelFloat/>
         <mu-text-field label="全拼" hintText="请输入全拼" v-model="form.fullPinYin"  lab labelFloat/>
         <mu-text-field label="五笔" hintText="请输入五笔" v-model="form.wubi"  lab labelFloat/>
         <mu-text-field label="关系" hintText="请输入关系" v-model="form.relationShip"  lab labelFloat/>
         <mu-text-field label="父级" hintText="请输入父级" v-model="form.parent"  lab labelFloat/>
         <mu-text-field label="等级" hintText="请输入等级" v-model="form.level"  lab labelFloat/>
         <mu-text-field label="排序" hintText="请输入排序" v-model="form.sort"  lab labelFloat/>
         <mu-text-field label="类型" hintText="请输入类型" v-model="form.type"  lab labelFloat/>
  </el-form>
  <span slot="footer" class="dialog-footer">
     <mu-raised-button label="取 消" class="demo-raised-button" @click="close()" secondary/>
     <span>  </span>
     <mu-raised-button label="确 定" class="demo-raised-button" @click="save()"/>
  </span>
</el-dialog>
</template>
<script>
export default {
  /** 组件名称 */
  name: "dics-edit",
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
      title: '新增字典表信息'
    };
  },
  methods: {
    /** 初始化 */
    init() {
      this.form = {
         /** 代码 */
        code: '',
         /** 名称 */
        name: '',
        /** 拼音简拼 */
        pinYin: '',
         /** 全拼 */
        fullPinYin: '',
         /** 五笔 */
        wubi: '',
         /** 关系 */
        relationShip: '',
         /** 父级 */
        parent: '',
         /** 等级 */
        level: '',
         /** 排序 */
        sort: '',
         /** 类型 */
        type: ''
      };
    },
    /** 隐藏页面 */
    close(refresh) {
      this.$emit('closeAdd', false, refresh);
    },
    /** 保存页面信息 */
    save() {
      let _this = this;
      this.$request.save('dics', this.form, function(respose) {
        if (respose.code === 1) {
          _this.init();
          _this.close(true);
        }
      }, this.id);
    },
   /** 打开页面信息 */
    open() {
      if (!this.id) {
        this.init();
      } else {
        this.title = '编辑字典表信息';
        let _this = this;
        this.$request.get('dics/' + this.id, {}, (respose) => {
          _this.form = respose.data;
        });
      }
    }
  }
};
</script>
