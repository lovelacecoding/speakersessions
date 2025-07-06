<template>
    <div class="container py-4">
      <title>Semantic demo</title>
      <header class="text-center mb-4">
        <!-- Accessible image with alt text -->
        <img src="https://cdn.eventory.cc/partners/2025/6/e87fce09-9729-480b-a44f-7aa41783e64e.jpg" width="200" height="200" class="img-fluid" alt="Code Europe logo" />

        <h1 class="fw-bold">Welcome to my Semantic VueJs fansite</h1>
      </header>

      <!-- Add main landmark -->
      <main>
        <img src="https://st2.depositphotos.com/1431107/11343/v/950/depositphotos_113431350-stock-illustration-pdf-document-download-icon.jpg" width="200" height="200" alt="Download PDF"/>

        <!-- High contrast text -->
        <p class="text-dark">This text has good contrast.</p>

        <UserForm />
        <ActionButton href="https://www.codeeurope.pl" />
      </main>

      <!-- Links with content -->
      <nav class="mt-3" aria-label="Quick links">
        <ul class="list-unstyled">
          <li><a href="#" class="link-primary">Home</a></li>
          <li><a href="https://example.com" class="link-primary">Example Link</a></li>
        </ul>
      </nav>
    </div>
</template>

<script>
import UserForm from '../semantic/UserForm.vue';
import ActionButton from '../semantic/ActionButton.vue';

export default {
  components: {
    UserForm,
    ActionButton,
  }
};
</script>

<style></style>
