<<template>
<div class="container">
  <mu-raised-button label="新增" class="demo-raised-button" @click="dialogVisible = true"/>
  <mu-raised-button label="编辑" class="demo-raised-button" primary/>
  <mu-raised-button label="停用" class="demo-raised-button" secondary/>
  <mu-raised-button label="删除" class="demo-raised-button" backgroundColor="#333"/>
  <mu-table :fixedFooter="fixedFooter" :fixedHeader="fixedHeader" :height="height"
    :enableSelectAll="true" :multiSelectable="multiSelectable"
    :selectable="selectable" :showCheckbox="showCheckbox" :allRowsSelected="true">
    <mu-thead slot="header">
      <mu-tr>
        <mu-th tooltip="序号">序号</mu-th>
        <mu-th tooltip="姓名">姓名</mu-th>
        <mu-th tooltip="状态">Status</mu-th>
        <mu-th tooltip="操作">操作</mu-th>
      </mu-tr>
    </mu-thead>
    <mu-tbody>
      <mu-tr v-for="item,index in tableData"  :key="index" :selected="item.selected">
        <mu-td>{{index + 1}}</mu-td>
        <mu-td>{{item.name}}</mu-td>
        <mu-td>{{item.status}}</mu-td>
        <mu-td><mu-icon value="update" color="#ff4081"/><i></i>
        <mu-icon value="stop" color="#ff4081"/><i></i>
        <mu-icon value="delete" color="#333"/><i></i></mu-td>
      </mu-tr>
    </mu-tbody>
    <mu-tfoot slot="footer">
      <mu-tr>
        <mu-td>ID</mu-td>
        <mu-td>Name</mu-td>
        <mu-td>Status</mu-td>
        <mu-td>
  </mu-td>
      </mu-tr>
    </mu-tfoot>
  </mu-table>
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
</div>
</template>
<script>
export default {
  data () {
    return {
      dialogVisible: false,
      tableData: [
        {
          name: "John Smith",
          status: "Employed",
          selected: true
        },
        {
          name: "Randal White",
          status: "Unemployed"
        },
        {
          name: "Stephanie Sanders",
          status: "Employed",
          selected: true
        },
        {
          name: "Steve Brown",
          status: "Employed"
        },
        {
          name: "Joyce Whitten",
          status: "Employed"
        },
        {
          name: "Samuel Roberts",
          status: "Employed"
        },
        {
          name: "Adam Moore",
          status: "Employed"
        }
      ],
      form: {
        TelName: "",
        TelPhone: "",
        TenantName: "",
        BusinessCertificate: "",
        EndTime: "",
        Type: ""
      },
      fixedHeader: true,
      fixedFooter: true,
      selectable: true,
      multiSelectable: true,
      enableSelectAll: false,
      showCheckbox: true,
      height: "800px"
    }
  },
  methods: {
    add () {
      this.$request.put('/api/tenant', this.form)
    }
  }
}
</script>

<style lang="css">
.demo-table-settings {
  width: 200px;
  overflow: hidden;
  margin: 20px auto 0px;
}
</style>