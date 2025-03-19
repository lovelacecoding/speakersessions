<template>
  <div class="container py-4">
    <header class="text-center mb-4">
      <h1 class="fw-bold">Welcome to my VueJs fansite</h1>
    </header>
    <!-- Low contrast text -->
    <p class="text-warning">This text has poor contrast.</p>

    <!-- Missing alternative text for images -->
    <img src="https://assets.jsworldconference.com/logo_vuejs_amsterdam_b4b41918cb.svg" width="200" height="200" class="img-fluid" />

    <UserForm />
    <ActionButton href="https://jsworld.com" />

    <!-- Empty links -->
    <nav class="mt-3">
      <ul class="list-unstyled">
        <li><a href="#" class="link-primary"></a></li>
        <li><a href="https://example.com" class="link-primary"></a></li>
      </ul>
    </nav>

    <!-- Missing document language in index.html -->
    <footer class="mt-4 text-center text-muted">
      <p>Note: The document language is missing in index.html</p>
    </footer>
  </div>
</template>

<script>
import UserForm from './components/UserForm.vue';
import ActionButton from './components/ActionButton.vue';

export default {
  components: {
    UserForm,
    ActionButton,
  }
};
</script>

<style></style>
