<template>
    <div>
        <h1>This is .Net8 Mvc with EF CodeFirst and Vue Base Demo .</h1>
        <div class="card flex justify-center">
            <Button label="Check" icon="pi pi-check" @click="hello" />
        </div>
    </div>
</template>

<script>
    import { onMounted } from 'vue';
    export default {
        name: 'Home',
        setup() {
            
            const hello = () => {
                alert("Hello Vue!");
            };

            
            onMounted(() => {
                console.log('Home.vue component mounted');
            });

            
            return {
                hello
            };
        }
    };
</script>