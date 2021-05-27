<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
    >
      <q-input
        filled
        v-model="workName"
        label="Сокращенное название"
        hint="Сокращенное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="fullName"
        label="Полное название"
        hint="Полное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="price"
        label="Цена за шт"
        hint="Цена за шт"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="quantity"
        label="Кол-во"
        hint="Кол-во"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="vat"
        label="НДС"
        hint="НДС"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="code"
        label="Код"
        hint="Код"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <div>
        <q-btn :loading="loading" label="Создать" type="submit" color="primary"/>
        <q-btn :loading="loading" label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  name: 'CreateProduct',
  data: () => {
    return {
      workName: null,
      fullName: null,
      code: null,
      vat: null,
      price: null,
      quantity: null,
      loading: false
    }
  },
  methods: {
    async onSubmit () {
      this.loading = true

      const product = {
        WorkName: this.workName,
        FullName: this.fullName,
        Code: this.code,
        Vat: this.vat,
        Price: this.price,
        Quantity: this.quantity
      }
      try {
        const result = await this.$store.dispatch('product/create', product)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Товар добавлен успешно'
          })
        }
        this.onReset()
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data.message
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.workName = null
      this.fullName = null
      this.code = null
      this.price = null
      this.quantity = null
      this.vat = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
