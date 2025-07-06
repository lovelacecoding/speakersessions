<template>
  <div class="container py-4">
    <title>Non-semantic demo</title>
    <div class="text-center mb-4">
      <!-- Missing alternative text for images -->
      <img src="https://cdn.eventory.cc/partners/2025/6/e87fce09-9729-480b-a44f-7aa41783e64e.jpg"
           width="200" height="200" class="img-fluid" />

      <div class="fw-bold">Welcome to my Non-Semantic VueJs fansite</div>
    </div>

    <img src="https://st2.depositphotos.com/1431107/11343/v/950/depositphotos_113431350-stock-illustration-pdf-document-download-icon.jpg"
         width="200" height="200"/>

    <!-- Low contrast text -->
    <div style="color:#f1caca">This text has poor contrast.</div>

    <UserForm />
    <ActionButton href="https://www.codeeurope.pl" />

    <!-- Empty links -->
    <div class="mt-3">
      <div class="list-unstyled">
        <div><div href="#" class="link-primary"></div></div>
        <div><div href="https://example.com" class="link-primary"></div></div>
      </div>
    </div>
  </div>
</template>

<script>
import UserForm from '../non-semantic/UserForm.vue';
import ActionButton from '../non-semantic/ActionButton.vue';

export default {
  components: {
    UserForm,
    ActionButton,
  }
};
</script>

<style></style>
