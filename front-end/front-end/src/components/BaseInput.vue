<template>
  <div class="form-input">
    <label :for="value">{{ label }}</label>
    <input
      :type="type"
      :id="value"
      :value="value"
      @input="$emit('input', $event.target.value)"  
    />
  </div>
</template>

<script>
export default {
  name: "BaseInput",
  props: {
    value: {
      type: [String, Number],
      required: true,
    },
    label: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: "text",
    },
  },
};
</script>

<style>
.form-input {
  margin-top: 20px;
  display: flex;
  flex-direction: column;
}
input {
  width: 100%;
  font-family: inherit;
  font-size: inherit;
  margin-top: 10px;
}
input[type="text"],
input[type="password"] {
  padding: 10px;
  border: 0;
  box-shadow: 0 0 15px 4px rgba(0, 0, 0, 0.1);
  border-radius: 5px;
}
input[type="text"]:hover,
input[type="password"]:hover {
  box-shadow: 0 0 15px 4px rgba(0, 0, 0, 0.3);
  transition: 0.3s box-shadow;
}
</style>