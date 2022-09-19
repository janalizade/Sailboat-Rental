<template>
  <div class="hello">
    <vue-chart :type="chart.type" :data="chart" :options="chart.options" />
  </div>
</template>

<script>

import VueChart from "vue-chart-js";

export default {
  name: "homecmp",
  components: {
    VueChart
  },
  props: {
    label: String,
    categories: Array,
    values: Array
  },
  computed: {
    chart() {
      return {
        type: "line",
        labels: this.categories,
        datasets: [
          {
            label: this.label,
            data: this.values
          }
        ],
        options: {
          scales: {
            xAxes: [{
              ticks: {
                autoSkip: true,
                maxTicksLimit: 12
              }
            }],
            yAxes: [{
              ticks: {
                autoSkip: true,
                maxTicksLimit: 6
              }
            }]
          }
        }
      };
    }
  }
};
</script>