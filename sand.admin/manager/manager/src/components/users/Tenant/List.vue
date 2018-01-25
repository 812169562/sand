
<template>
<div class="container">
  <el-row>
    <el-col :xs="18" :sm="18" :md="18" :lg="18" :xl="18">
       <mu-raised-button label="新增" class="demo-raised-button"  @click="add()" />
       <mu-raised-button label="编辑" class="demo-raised-button"  primary/>
       <mu-raised-button label="停用" class="demo-raised-button"  secondary backgroundColor="#f78989" @click="stop()"/>
       <mu-raised-button label="启用" class="demo-raised-button" backgroundColor="#85ce61" @click="stop(null,true)"/>
       <mu-raised-button label="删除" class="demo-raised-button" backgroundColor="#909399" @click="del()"/>
    </el-col>
    <el-col :xs="6" :sm="6" :md="6" :lg="6" :xl="6">
      <mu-text-field   class="appbar-search-field"  hintText="请输入搜索内容" v-model="queryData"  />
      <el-button type="success" plain size="small" @click="query()">检索</el-button>
    </el-col>
</el-row>
 <el-table ref="multipleTable"  column-key="tenantId" tooltip-effect="dark" style="width: 100%" max-height="780" size="small" :data="tenantData"  @selection-change="handleSelectionChange">>
    <el-table-column prop="selected" type="selection"  width="55" > </el-table-column>
    <el-table-column type="index" label="序号"    width="55"></el-table-column>
    <el-table-column prop="tenantName" label="名称" width="120"></el-table-column>
    <el-table-column prop="telName"  label="联系人"  width="180"></el-table-column>
    <el-table-column prop="telPhone" label="联系电话"  width="180"></el-table-column>
    <el-table-column prop="status" label="状态" width="180" ></el-table-column>
    <el-table-column label="操作"  align="right">
    <template slot-scope="scope">
      <el-button size="mini"  type="primary"  @click="edit(scope.row)">编辑</el-button>   
      <el-button size="mini"  type="danger" v-if="scope.row.isEnable"  @click="stop(scope.row)">停用</el-button>
      <el-button size="mini"  type="success"  v-else @click="stop(scope.row,true)">启用</el-button>
      <el-button size="mini"  type="info"  @click="del(scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
    <el-pagination
         @size-change="sizeChange"
         @current-change="currentChange"
         :current-page="current"
         :page-sizes="pageSizeOption"
         :page-size="pageSize"
         layout="total, sizes, prev, pager, next, jumper"
         :total="total">
        </el-pagination>
 <tenant-add :dialogVisible="dialog" @closeAdd="_addClose"></tenant-add>
</div>
</template>
<script>
import TenantAdd from './Add'
export default {
  data () {
    return {
      tenantData: [],
      dialog: false,
      total: 15,
      current: 1,
      showSizeChanger: true,
      pageSize: 15,
      pageSizeOption: [15, 30, 50, 100],
      queryData: '',
      multipleSelection: []
    }
  },
  mounted: function () {
    this.query()
  },
  methods: {
    query (pagesize) {
      let _this = this
      this.$request.get("tenant/page", { pageIndex: _this.current, pageSize: _this.pageSize, queryData: _this.queryData }, (respose) => {
        _this.tenantData = respose.data.result
        _this.total = respose.data.totalCount
        _this.current = respose.data.data.pageIndex
      })
    },
    add () {
      this.dialog = true
    },
    del (row) {
      let tenant = this.selectdata(row)
      if (!tenant || tenant.length === 0) {
        this.$message.error('请选择一条数据！')
        return
      }
      this.$request.delete('tenant', { tenant }, (respose) => {
        this.query()
      })
    },
    edit (rtenantow) {

    },
    stop (row, isEnable) {
      let tenant = this.selectdata(row)
      if (!tenant || tenant.length === 0) {
        this.$message.error('请选择一条数据！')
        return
      }
      // if (tenant.(t=> t.isEnable!=isEnable)) {
      //   this.$message.error('请选择同一种类型进行批量操作！')
      //   return
      // }
      let msg = ''
      if (isEnable) {
        msg = '是否启用该项目？'
      }
      this.$request.stop('tenant/stop', {tenant, isEnable}, (respose) => {
        this.query()
      }, null, msg)
    },
    sizeChange (pageSize) {
      this.pageSize = pageSize
      this.query()
    },
    currentChange (current) {
      this.current = current
      this.query()
    },
    handleSelectionChange (val) {
      this.multipleSelection = val
    },
    _addClose (evtValue, refresh) {
      this.dialog = evtValue
      if (refresh) {
        this.query()
      }
    },
    selectdata (row) {
      let tenant = []
      if (row) {
        tenant.push(row)
      } else {
        this.multipleSelection.forEach(element => {
          tenant.push(element)
        })
      }
      return tenant
    }
  },
  components: {
    "tenant-add": TenantAdd
  }
}
</script>


