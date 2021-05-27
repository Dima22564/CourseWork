<template>
  <q-page padding>
    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
    >
      <q-input
        filled
        dense
        v-model="name"
        label="Название страны"
        hint="Название страны"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="code"
        label="Номер страны"
        hint="Номер страны"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="fullName"
        label="Полное название"
        hint="Полное название"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="code2"
        label="Символьный код(2 знака)"
        hint="Символьный код(2 знака)"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="code3"
        label="Символьный код(3 знака)"
        hint="Символьный код(3 знака)"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <div>
        <q-btn label="Добавить" size="md" type="submit" color="primary" :loading="loading"/>
        <q-btn label="Сбросить" size="md" type="reset" color="primary" flat class="q-ml-sm" :loading="loading" />
      </div>
    </q-form>

  </q-page>
</template>

<script>
export default {
  name: 'PageCountryAdd',
  data: () => {
    return {
      name: null,
      code: null,
      fullName: null,
      code2: null,
      code3: null,
      loading: false
    }
  },
  methods: {
    async onSubmit () {
      const data = new FormData()
      data.append('Name', this.name)
      data.append('Code', this.code)
      data.append('FullName', this.fullName)
      data.append('Code2', this.code2)
      data.append('Code3', this.code3)
      this.loading = true
      try {
        const result = await this.$store.dispatch('country/create', data)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Страна добавлена успешно'
          })
        }
        this.onReset()
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.name = null
      this.code = null
      this.fullName = null
      this.code2 = null
      this.code3 = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
