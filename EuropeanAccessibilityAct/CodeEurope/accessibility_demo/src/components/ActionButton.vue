<template>
  <div class="d-flex gap-2 mt-3" id="actionbutton">
    <a v-if="href" :href="href" class="btn btn-secondary">
      <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
        <path d="M5 12h14M12 5l7 7-7 7" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
    </a>
  </div>
</template>
\
<script>
export default {
  props: {
    href: {
      type: String,
      required: false,
    },
  },
};
</script>

<style scoped>

</style>
