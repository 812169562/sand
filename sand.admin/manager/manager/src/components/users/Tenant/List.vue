
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
      <mu-text-field   class="appbar-search-field"  hintText="请输入搜索内容" v-model="queryData"  />
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
      <mu-tr v-for="item,index in tenantData" :key="index" :selected="item.selected">
        <mu-td>{{index + 1}}</mu-td>
        <mu-td>{{item.tenantName}}</mu-td>
        <mu-td>{{item.telName}}</mu-td>
        <mu-td>{{item.telPhone}}</mu-td>
        <mu-td>{{item.status}}</mu-td>
        <mu-td><mu-icon-button tooltip="编辑" icon="update" @click="edit(item.TenantId)"/>
        <mu-icon-button tooltip="停用" icon="stop" @click="stop(item.TenantId)"/>
        <mu-icon-button tooltip="删除" icon="delete" @click="del(item.TenantId)"/>
        </mu-td>
      </mu-tr> 
    </mu-tbody>
    <mu-tfoot slot="footer">
      <mu-tr>
        <!-- <mu-td tooltip="序号">序号</mu-td>
        <mu-td tooltip="名称">名称</mu-td>
        <mu-td tooltip="联系人">联系人</mu-td>
        <mu-td tooltip="状态">状态</mu-td>
        <mu-td tooltip="操作">操作</mu-td> -->
        <mu-td>
         <!-- <el-row type="flex" justify="end">
             <mu-pagination :total="total" :current="current" 
             :showSizeChanger="showSizeChanger" :pageSizeOption="pageSizeOption" :pageSize="pageSize"
             @pageSizeChange="query" @pageChange="query()">
             </mu-pagination>
         </el-row> -->

      <div class="block">
       <el-pagination
         @size-change="sizeChange"
         @current-change="currentChange"
         :current-page="current"
         :page-sizes="pageSizeOption"
         :page-size="pageSize"
         layout="total, sizes, prev, pager, next, jumper"
         :total="total">
        </el-pagination>
          </div>
        </mu-td>
      </mu-tr>
    </mu-tfoot>
  </mu-table>
 <tenant-add :dialogVisible="dialog" @closeAdd="_addClose"></tenant-add>
</div>
</template>
<script>
import TenantAdd from "./Add"
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
      tenantData: [],
      dialog: false,
      total: 15,
      current: 1,
      showSizeChanger: true,
      pageSize: 15,
      pageSizeOption: [15, 30, 50, 100],
      queryData: ''
    }
  },
  mounted: function () {
    this.query()
  },
  methods: {
    query (pagesize) {
      let _this = this
      this.$request.get("tenant/page", { pageIndex: _this.current, pageSize: _this.pageSize, queryData: _this.queryData }, function (respose) {
        _this.tenantData = respose.data.result
        _this.total = respose.data.totalCount
        _this.current = respose.data.data.pageIndex
      })
    },
    add () {
      this.dialog = true
    },
    del (ids) {
      console.log(this.tenantData)
      console.log(ids)
    },
    edit (id) {

    },
    stop (ids) {

    },
    sizeChange (pageSize) {
      this.pageSize = pageSize
      this.query()
    },
    currentChange (current) {
      this.current = current
      this.query()
    },
    _addClose (evtValue, refresh) {
      this.dialog = evtValue
      if (refresh) {
        this.query()
      }
    }
  },
  components: {
    "tenant-add": TenantAdd
  }
}
</script>
<style scoped>
  .red {
    color: red
  }
</style>


