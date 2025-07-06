<template>
  <div class="d-flex gap-2 mt-3">
    <a v-if="href" :href="href" class="btn btn-secondary" aria-label="Go to Code Europe">
      <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" role="img">
        <path d="M5 12h14M12 5l7 7-7 7" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
      </svg>
      <span class="visually-hidden">Visit website</span>
    </a>
  </div>
</template>

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
.visually-hidden {
  position: absolute;
  width: 1px;
  height: 1px;
  padding: 0;
  margin: -1px;
  overflow: hidden;
  clip: rect(0, 0, 0, 0);
  white-space: nowrap;
  border-width: 0;
}
</style>
