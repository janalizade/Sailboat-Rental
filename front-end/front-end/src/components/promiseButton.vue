<template>
  <v-btn v-bind="$attrs" :loading="isLoading" @click="buttonClicked()">
    <slot></slot>
  </v-btn>
</template>

<script>
export default {
  name: "PromiseButton",
  props: ["onClickMethod"],
  data() {
    return {
      isLoading: false
    };
  },
  methods: {
    buttonClicked() {

      this.isLoading = true;

      Promise.resolve(this.onClickMethod()).finally(() =>
        this.isLoading = false
      );

    }
  }
};
</script>
