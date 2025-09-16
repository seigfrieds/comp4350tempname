<!-- Where the JS/TS goes -->
<script setup lang="ts">
import { ref } from "vue";
import config from "./config.ts";

interface TypeScriptType {
  prop: string;
}

const hello = ref<TypeScriptType>({ prop: "Hello world!" });
</script>

<!-- Where the HTML goes -->
<template>
  <h1>{{ hello.prop }}</h1>
  <h1>{{ config.example }}</h1>
  <nav>
    <router-link to="/">Go to Home</router-link>
    <router-link to="/about">Go to About</router-link>
  </nav>
  <main>
    <router-view />
  </main>
</template>

<!-- Where styling goes -->
<style scoped>
/* note: scoped means the styles only affect THIS component */
</style>
