<template>
    <v-dialog v-model="show"
              max-width="320"
              persistent>
        <v-card class="pa-4" style="border-radius:14px;">
            <v-row align="center" justify="start" no-gutters>
                <!-- Loader à gauche -->
                <v-col cols="auto">
                    <v-progress-circular indeterminate
                                         size="26"
                                         width="5"
                                         color="primary" />
                </v-col>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <!-- Texte à droite -->
                <v-col>
                    <span class="text-subtitle-1">Applying changes...</span>
                </v-col>
            </v-row>
        </v-card>
    </v-dialog>
</template>

<script setup>
    import { useLoadingDialog } from "../../utils/loadingDialog";

    const { show } = useLoadingDialog();
</script>
