<template>
    <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
            <v-col cols="12" sm="8" md="4">
                <v-card>
                    <v-card-title>Connexion</v-card-title>
                    <v-card-text>
                        <v-text-field v-model="username"
                                      label="Nom d'utilisateur"
                                      outlined
                                      dense />
                    </v-card-text>
                    <v-card-actions>
                        <v-btn color="primary" block @click="login">
                            Se connecter
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
    export default {
        name: 'LoginPage',lo
        data() {
            return {
                username: '',
            }
        },
        methods: {
            login() {
                if (this.username.trim()) {
                    this.$store.dispatch('login', this.username)
                    this.$router.push('/chat')
                }
            },
        },
    }
</script>
