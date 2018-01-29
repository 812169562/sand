<<template>
<div class="container">
  <mu-raised-button label="新增" class="demo-raised-button"/>
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
</div>
</template>
<script>
export default {
  data() {
    return {
      tableData: [
        {
          name: 'John Smith',
          status: 'Employed',
          selected: true
        },
        {
          name: 'Randal White',
          status: 'Unemployed'
        },
        {
          name: 'Stephanie Sanders',
          status: 'Employed',
          selected: true
        },
        {
          name: 'Steve Brown',
          status: 'Employed'
        },
        {
          name: 'Joyce Whitten',
          status: 'Employed'
        },
        {
          name: 'Samuel Roberts',
          status: 'Employed'
        },
        {
          name: 'Adam Moore',
          status: 'Employed'
        }
      ],
      fixedHeader: true,
      fixedFooter: true,
      selectable: true,
      multiSelectable: true,
      enableSelectAll: false,
      showCheckbox: true,
      height: '300px'
    };
  }
};
</script>

<style lang="css">
.demo-table-settings {
  width: 200px;
  overflow: hidden;
  margin: 20px auto 0px;
}
</style>
