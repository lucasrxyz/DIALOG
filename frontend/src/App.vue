<script setup>
    import LoadingDialog from "./components/dialoading/LoadingDialog.vue";
</script>

<template>
    <v-app>
        <v-main>
            <router-view />
            <LoadingDialog />
        </v-main>
    </v-app>
</template>

<style>
    html, body, #app {
        margin: 0;
        padding: 0;
        height: 100%;
        font-family: 'Calibri', sans-serif;
    }
</style>
