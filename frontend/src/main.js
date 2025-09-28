import { createApp } from 'vue'
import App from './App.vue'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

// Router
import router from './router'

// Vuex
import store from './store'

const vuetify = createVuetify({
    components,
    directives,
    theme: {
        defaultTheme: 'dark', // 'light' | 'dark' | 'system'
    },
    typography: {
        fontFamily: 'Arial, sans-serif',
    },
})

createApp(App)
    .use(vuetify)
    .use(router)
    .use(store)
    .mount('#app')
