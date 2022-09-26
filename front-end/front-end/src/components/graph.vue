<template>
    <v-sheet class="mt-2 ml-7 v-sheet--offset mx-auto" width="200px" color="#f7fbfb" height="100px">
      <v-sparkline
        type="bar"
        :gradient="gradient"
        :labels="labels"
        :value='graphValue'
         color="#FEF3F3"
         line-width="30"
         height="200"
         width="400"
         padding="24"
         stroke-linecap="round"
         smooth
      />
   </v-sheet>
</template>

<script>

const gradients = [
  ['#222'],
  ['#42b3f4'],
  ['red', 'orange', 'yellow'],
  ['purple', 'violet'],
  ['#00c6ff', '#F0F', '#FF0'],
  ['#f72047', '#ffd200', '#1feaea'],
]

export default {
  props: [
    'graphValue',
    'graphName'
  ],
  data: () => ({
    gradient: gradients[5],
    labels: [
      'Jan',
      'Feb',
      'Mar',
      'Apr',
      'May',
      'Jun',
      'Jul',
      'Aug',
      'Sep',
      'Oct',
      'Nov',
      'Dec'
    ]
  })
};

</script>

<style>
  .v-sheet--offset {
    top: -24px;
    position: relative;
  }
</style>