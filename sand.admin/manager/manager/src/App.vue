<template>
  <div>
    <mu-appbar title="控制台">
      <mu-icon-button icon="menu" slot="left" v-on:click="show()" />
      <mu-text-field icon="search" class="appbar-search-field" slot="right" hintText="请输入搜索内容" />
      <mu-flat-button color="white" label="检索" slot="right" />
    </mu-appbar>
    <el-container>
      <el-aside width="200px">
        <mu-list>
          <mu-list-item toggleNested title="租户管理">
            <mu-list-item href="#/user" slot="nested" title="租户信息"> </mu-list-item>
             <mu-list-item href="#/tenant" slot="nested" title="用户"> </mu-list-item>
          </mu-list-item>
        </mu-list>
      </el-aside>
      <el-container>
        <el-main>
          <router-view></router-view>
        </el-main>
        <!-- <el-footer>Footer</el-footer> -->
      </el-container>
    </el-container>
  </div>
</template>
<<script>
export default {
  methods: {
    show: function () {
      alert('1')
    }
  }
}
</script>
