<template>
  <section id="newsletter-signup">
    <h2 class="fw-bold mt-2">Sign up for my newsletter</h2>
    <form class="mt-3 p-3 border rounded shadow-sm">
      <div class="mb-3">
        <label for="name" class="form-label">Enter your name:</label>
        <input type="text" id="name" class="form-control" placeholder="e.g. Louella Creemers" aria-required="true" />
      </div>
      <div class="mb-3">
        <label for="email" class="form-label">Enter your email:</label>
        <input type="email" id="email" class="form-control" placeholder="e.g. lou@hotmail.com" aria-required="true" />
      </div>
      <button type="submit" class="btn btn-primary w-100">Submit</button>
    </form>
  </section>
</template>

<style scoped>

</style>
<script setup lang="ts">
</script>
