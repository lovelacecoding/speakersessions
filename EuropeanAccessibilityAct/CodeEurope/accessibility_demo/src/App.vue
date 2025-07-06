<template>
  <div class="container py-4">
    <header class="text-center mb-4">
      <h1 class="fw-bold">Welcome to my VueJs fansite</h1>
      <!-- Missing alternative text for images -->
      <img src="https://cdn.eventory.cc/partners/2025/6/e87fce09-9729-480b-a44f-7aa41783e64e.jpg" width="200" height="200" class="img-fluid" />
    </header>

    <img src="https://st2.depositphotos.com/1431107/11343/v/950/depositphotos_113431350-stock-illustration-pdf-document-download-icon.jpg" width="200" height="200"/>

    <!-- Low contrast text -->
    <p class="text-warning">This text has poor contrast.</p>

    <UserForm />
    <ActionButton href="https://www.codeeurope.pl" />

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
