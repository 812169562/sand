<
<template>
<div class="container">
  <el-row>
    <el-col :xs="18" :sm="18" :md="18" :lg="18" :xl="18">
  <mu-raised-button label="新增" class="demo-raised-button"  @click="add()" />
  <mu-raised-button label="编辑" class="demo-raised-button"  primary/>
 <mu-raised-button label="停用" class="demo-raised-button"  secondary/>
 <mu-raised-button label="删除" class="demo-raised-button" backgroundColor="#333"/>
 </el-col>
 <el-col :xs="6" :sm="6" :md="6" :lg="6" :xl="6">
    <mu-text-field   class="appbar-search-field"  hintText="请输入搜索内容" />
   <mu-raised-button color="green" class="demo-raised-button"  backgroundColor="#FFF0F5" label="检索" @click="query()"  />
 </el-col>
  </el-row>
  <mu-table :fixedFooter="fixedFooter" :fixedHeader="fixedHeader" :height="height"
    :enableSelectAll="true" :multiSelectable="multiSelectable"
    :selectable="selectable" :showCheckbox="showCheckbox" :allRowsSelected="true">
    <mu-thead slot="header">
      <mu-tr>
        <mu-th tooltip="序号">序号</mu-th>
        <mu-th tooltip="名称">名称</mu-th>
        <mu-th tooltip="联系人">联系人</mu-th>
        <mu-th tooltip="联系电话">联系电话</mu-th>
        <mu-th tooltip="状态">状态</mu-th>
        <mu-th tooltip="操作">操作</mu-th>
      </mu-tr>
    </mu-thead>
    <mu-tbody>
      <mu-tr v-for="item,index in tableData"  :key="index" :selected="item.selected">
        <mu-td>{{index + 1}}</mu-td>
        <mu-td>{{item.tenantName}}</mu-td>
        <mu-td>{{item.telName}}</mu-td>
        <mu-td>{{item.telPhone}}</mu-td>
        <mu-td>{{item.status}}</mu-td>
        <mu-td><mu-icon value="update" color="#ff4081"/><i></i>
        <mu-icon value="stop" color="#ff4081"/><i></i>
        <mu-icon value="delete" color="#333"/><i></i></mu-td>
      </mu-tr>
    </mu-tbody>
    <mu-tfoot slot="footer">
      <mu-tr>
        <mu-th tooltip="序号">序号</mu-th>
        <mu-th tooltip="名称">名称</mu-th>
        <mu-th tooltip="联系人">联系人</mu-th>
        <mu-th tooltip="联系电话">联系电话</mu-th>
        <mu-th tooltip="状态">状态</mu-th>
        <mu-th tooltip="操作">操作</mu-th>
  </mu-td>
      </mu-tr>
    </mu-tfoot>
  </mu-table>
 <tenant-add :dialogVisible="dialog"></tenant-add>
</div>
</template>
<script>
import TenantAdd from './Tenant/Add'
export default {
  data () {
    return {
      fixedHeader: true,
      fixedFooter: true,
      selectable: true,
      multiSelectable: true,
      enableSelectAll: false,
      showCheckbox: true,
      height: "600px",
      tableData: [],
      dialog: false
    }
  },
  creaded: function () {
    this.query()
  },
  methods: {
    query () {
      let _this = this
      this.$request.get('/api/tenant', {TenantName: ''}, function (respose) {
        _this.tableData = respose.data.data
      })
    },
    add () {
      this.dialog = true
    }
  },
  components: {
    'tenant-add': TenantAdd
  }
}
</script>
