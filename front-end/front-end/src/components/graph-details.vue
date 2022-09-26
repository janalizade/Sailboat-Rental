<template>
  <div id="chart">
    <VueApexCharts
      type="line"
      :height="height"
      :width="width"
      :options="chartOptions"
      :series="series"
    />
  </div>
</template>

<script type="text/javascript">

import VueApexCharts from 'vue-apexcharts';

export default {
  name: "homecmp",
  components: {
    VueApexCharts
  },
  props: [
    'label',
    'categories',
    'values',
    'height',
    'width'

  ],
  data() {
    return {
      series: [
        {
          name: this.label,
          type: 'column',
          data: this.values
        },
        {
          name: this.label,
          type: 'line',
          data: this.values
        }
      ],
      chartOptions: {
        chart: {
          id: 'vuechart-example',
          toolbar: {
            show: false,
            offsetX: 0,
            offsetY: 0,
            tools: {
              download: false,
              selection: false,
              zoom: false,
              zoomin: false,
              zoomout: false,
              pan: false,
              reset:false
            }
          }
        },
        colors: ['#71A8BE', '#ADDAD9'],
        stroke: {
          width: [0, 4]
        },
        title: {
          show: false
        },
        legend: {
          show: false
        },
        tooltip: {
          show: false
        },
        dataLabels: {
          enabled: true,
          enabledOnSeries: [1]
        },
        labels: this.categories,
        grid: {
          show: false
        },
        xaxis: {
          tooltip: {
            enabled: false
          },
          position: 'bottom',
          axisBorder: {
            show: true
          },
          axisTicks: {
            show: true
          }
        },
        yaxis: {
          axisBorder: {
            show: true
          },
          axisTicks: {
            show: true,
          },
          tooltip: {
            enabled: false
          },
          labels: {
            show: true
          }
        }
      }
    };
  }
};

</script>
