
<template>
<div class="container">
  <el-row>
    <el-col :xs="18" :sm="18" :md="14" :lg="17" :xl="18">
       <mu-raised-button label="新增" class="demo-raised-button"  @click="add()" />
       <mu-raised-button label="停用" class="demo-raised-button"  secondary backgroundColor="#f78989" @click="stop()"/>
       <mu-raised-button label="启用" class="demo-raised-button" backgroundColor="#85ce61" @click="stop(null,true)"/>
       <mu-raised-button label="删除" class="demo-raised-button" backgroundColor="#909399" @click="del()"/>
    </el-col>
    <el-col :xs="6" :sm="6" :md="10" :lg="7" :xl="6">
      <mu-text-field   class="appbar-search-field"  hintText="请输入搜索内容" v-model="queryData"  />
      <el-button type="success" plain size="small" @click="query()">检索</el-button>
    </el-col>
</el-row>
 <el-table ref="multipleTable"  column-key="tenantId" tooltip-effect="dark" style="width: 100%" max-height="780" :height="fullHeight" size="small" :data="tenantData"  @selection-change="handleSelectionChange">>
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
 <tenant-add :dialogVisible="dialog" @closeAdd="_addClose" :id="childId"></tenant-add>
</div>
</template>
<script>
import TenantAdd from './Add';
export default {
  /** 页面绑定数据 */
  data() {
    return {
      /** 页面table绑定数据 */
      tenantData: [],
      /** 新增编辑页面弹出框  */
      dialog: false,
      /** 分页总数据 初次加载绑定用 */
      total: 15,
      /** 当前页 */
      current: 1,
      /** 是否显示分页大小 */
      showSizeChanger: true,
      /** 当前页 */
      pageSize: 15,
      /** 每页数据大小 */
      pageSizeOption: [15, 30, 50, 100],
      /** 查询数据 */
      queryData: '',
      /** 已选中的数据 */
      multipleSelection: [],
      /** 当前窗体高度 */
      fullHeight: document.documentElement.clientHeight - 200,
      /** 子页面编号 */
      childId: ''
    };
  },
  /**  初始化只执行一次 */
  mounted: function() {
    this.query();
    // 然后监听window的resize事件．在浏览器窗口变化时再设置下背景图高度．
    const that = this;
    window.onresize = () => {
      that.fullHeight = document.documentElement.clientHeight - 200;
    };
  },
  methods: {
    /**  查询分页信息 @for Tenant */
    query() {
      let _this = this;
      this.$request.get(
        'tenant/page',
        {
          pageIndex: _this.current,
          pageSize: _this.pageSize,
          queryData: _this.queryData
        },
        respose => {
          _this.tenantData = respose.data.result;
          _this.total = respose.data.totalCount;
          _this.current = respose.data.data.pageIndex;
        }
      );
    },
    /**  弹出添加数据页面 @for Tenant */
    add() {
      this.dialog = true;
    },
    /**  删除选中数据  @for Tenant
     * @param 当前选中数据
     */
    del(row) {
      let tenant = this.selectdata(row);
      if (!tenant || tenant.length === 0) {
        this.$message.error('请选择一条数据！');
        return;
      }
      this.$request.delete('tenant', { tenant }, respose => {
        this.query();
      });
    },
    /**  编辑选中数据  @for Tenant
     * @param 当前选中数据
     */
    edit(tenant) {
      this.childId = tenant.id;
      this.dialog = true;
    },
    /**  停用选中数据  @for Tenant
     * @param 当前选中数据
     */
    stop(row, isEnable) {
      let tenant = this.selectdata(row);
      if (!tenant || tenant.length === 0) {
        this.$message.error('请选择一条数据！');
        return;
      }
      // if (tenant.(t=> t.isEnable!=isEnable)) {
      //   this.$message.error('请选择同一种类型进行批量操作！')
      //   return
      // }
      let msg = '';
      if (isEnable) {
        msg = '是否启用该项目？';
      }
      this.$request.stop(
        'tenant/stop',
        { tenant, isEnable },
        respose => {
          this.query();
        },
        null,
        msg
      );
    },
    /**  事件-修改分页大小  @for Tenant
     * @param 选中分页大小
     */
    sizeChange(pageSize) {
      this.pageSize = pageSize;
      this.query();
    },
    /** 事件-改变分页当前页   @for Tenant
     * @param 选中分页大小
     */
    currentChange(current) {
      this.current = current;
      this.query();
    },
    /** 事件-选中行   @for Tenant
     * @param 当前选中行
     */
    handleSelectionChange(val) {
      this.multipleSelection = val;
    },
    /** 回调-子窗口添加完成之后回调关闭刷新当前页面   @for Tenant
     * @param 当前选中行
     */
    _addClose(evtValue, refresh) {
      this.dialog = evtValue;
      if (refresh) {
        this.query();
      }
    },
    /** 添加当前选中数据到集合内   @for Tenant
     * @param 当前选中行
     */
    selectdata(row) {
      let tenant = [];
      if (row) {
        tenant.push(row);
      } else {
        this.multipleSelection.forEach(element => {
          tenant.push(element);
        });
      }
      return tenant;
    }
  },
  /** 引用组建 */
  components: {
    'tenant-add': TenantAdd
  }
};
</script>
